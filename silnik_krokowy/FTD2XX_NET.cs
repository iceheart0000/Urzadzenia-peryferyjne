using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FTD2XX_NET
{
    public class FTDI
    {
       
        public const UInt32 FT_OPEN_BY_SERIAL_NUMBER = 1;
        public const UInt32 FT_OPEN_BY_DESCRIPTION = 2;
        public const UInt32 FT_OPEN_BY_LOCATION = 4;

        public const byte FT_BITMODE_RESET = 0x00;
        public const byte FT_BITMODE_ASYNC_BITBANG = 0x01;

        private IntPtr ftHandle = IntPtr.Zero;


        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern FT_STATUS FT_Open(UInt32 uiDevice, ref IntPtr pftHandle);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern FT_STATUS FT_OpenEx(string lpDeviceString, UInt32 dwFlags, ref IntPtr pftHandle);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern FT_STATUS FT_Close(IntPtr ftHandle);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern FT_STATUS FT_Write(IntPtr ftHandle, byte[] lpBuffer, UInt32 dwBytesToWrite, ref UInt32 lpdwBytesWritten);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern FT_STATUS FT_SetBitMode(IntPtr ftHandle, byte ucMask, byte ucEnable);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern FT_STATUS FT_CreateDeviceInfoList(ref UInt32 lpdwNumDevs);

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern FT_STATUS FT_GetDeviceInfoList([Out] FT_DEVICE_INFO_NODE[] pDest, ref UInt32 lpdwNumDevs);


        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FT_EE_ReadEx")]
        private static extern FT_STATUS FT_EEPROM_Read_Native(
            IntPtr ftHandle,
            ref FT_PROGRAM_DATA_V0 lpData,
            [Out] StringBuilder Manufacturer,
            [Out] StringBuilder ManufacturerID,
            [Out] StringBuilder Description,
            [Out] StringBuilder SerialNumber
        );

        [DllImport("FTD2XX.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FT_EE_ProgramEx")]
        private static extern FT_STATUS FT_EEPROM_Write_Native(
            IntPtr ftHandle,
            ref FT_PROGRAM_DATA_V0 lpData, 
            [In] string Manufacturer,
            [In] string ManufacturerID,
            [In] string Description,
            [In] string SerialNumber
        );



        public bool IsOpen
        {
            get { return (ftHandle != IntPtr.Zero); }
        }
        public FT_STATUS OpenByIndex(UInt32 index)
        {
            return FT_Open(index, ref ftHandle);
        }
        public FT_STATUS OpenBySerialNumber(string serialNumber)
        {
            return FT_OpenEx(serialNumber, FT_OPEN_BY_SERIAL_NUMBER, ref ftHandle);
        }
        public FT_STATUS Close()
        {
            FT_STATUS status = FT_Close(ftHandle);
            if (status == FT_STATUS.FT_OK) ftHandle = IntPtr.Zero;
            return status;
        }
        public FT_STATUS Write(byte[] data, UInt32 bytesToWrite, ref UInt32 bytesWritten)
        {
            return FT_Write(ftHandle, data, bytesToWrite, ref bytesWritten);
        }
        public FT_STATUS SetBitMode(byte mask, byte mode)
        {
            return FT_SetBitMode(ftHandle, mask, mode);
        }
        public FT_STATUS GetNumberOfDevices(ref UInt32 numDevices)
        {
            return FT_CreateDeviceInfoList(ref numDevices);
        }
        public FT_STATUS GetDeviceList(FT_DEVICE_INFO_NODE[] deviceList)
        {
            UInt32 numDevices = (UInt32)deviceList.Length;
            return FT_GetDeviceInfoList(deviceList, ref numDevices);
        }

        private FT_PROGRAM_DATA_V0 CreateProgramData()
        {
            FT_PROGRAM_DATA_V0 data = new FT_PROGRAM_DATA_V0();

            data.Signature1 = 0x00000000;
            data.Signature2 = 0xFFFFFFFF;


            data.Version = 0;

            data.Manufacturer = IntPtr.Zero;
            data.ManufacturerId = IntPtr.Zero;
            data.Description = IntPtr.Zero;
            data.SerialNumber = IntPtr.Zero;

            return data;
        }

        public FT_STATUS ReadEEPROM(out string serial, out string desc, out UInt16 vid, out UInt16 pid)
        {
            serial = string.Empty;
            desc = string.Empty;
            vid = 0;
            pid = 0;

            try
            {
                FT_PROGRAM_DATA_V0 eepromData = CreateProgramData();

                StringBuilder sbSerial = new StringBuilder(64);
                StringBuilder sbDesc = new StringBuilder(128);
                StringBuilder sbMfg = new StringBuilder(64);
                StringBuilder sbMfgId = new StringBuilder(64);

                FT_STATUS status = FT_EEPROM_Read_Native(
                    ftHandle,
                    ref eepromData,
                    sbMfg,
                    sbMfgId,
                    sbDesc,
                    sbSerial
                );

                if (status == FT_STATUS.FT_OK)
                {
                    serial = sbSerial.ToString();
                    desc = sbDesc.ToString();
                    vid = eepromData.VendorId;
                    pid = eepromData.ProductId;
                }
                return status;
            }
            catch (Exception)
            {
                return FT_STATUS.FT_OTHER_ERROR;
            }
        }


        public FT_STATUS WriteEEPROM(string serial, string desc)
        {
            try
            {
               
                FT_PROGRAM_DATA_V0 eepromData = CreateProgramData();
                StringBuilder sbSerial = new StringBuilder(64);
                StringBuilder sbDesc = new StringBuilder(128);
                StringBuilder sbMfg = new StringBuilder(64);
                StringBuilder sbMfgId = new StringBuilder(64);

                FT_STATUS status = FT_EEPROM_Read_Native(
                    ftHandle,
                    ref eepromData,
                    sbMfg,
                    sbMfgId,
                    sbDesc,
                    sbSerial
                );

                if (status != FT_STATUS.FT_OK)
                {
                    
                    return status;
                }

               
                status = FT_EEPROM_Write_Native(
                    ftHandle,
                    ref eepromData,
                    sbMfg.ToString(),
                    sbMfgId.ToString(), 
                    desc, 
                    serial 
                );

                return status;
            }
            catch (Exception)
            {
                return FT_STATUS.FT_OTHER_ERROR;
            }
        }
    }

    public enum FT_STATUS
    {
        FT_OK = 0,
        FT_INVALID_HANDLE,
        FT_DEVICE_NOT_FOUND,
        FT_DEVICE_NOT_OPENED,
        FT_IO_ERROR,
        FT_INSUFFICIENT_RESOURCES,
        FT_INVALID_PARAMETER,
        FT_INVALID_BAUD_RATE,
        FT_DEVICE_NOT_OPENED_FOR_ERASE,
        FT_DEVICE_NOT_OPENED_FOR_WRITE,
        FT_FAILED_TO_WRITE_DEVICE,
        FT_EEPROM_READ_FAILED,
        FT_EEPROM_WRITE_FAILED,
        FT_EEPROM_ERASE_FAILED,
        FT_EEPROM_NOT_PRESENT,
        FT_EEPROM_NOT_PROGRAMMED,
        FT_INVALID_ARGS,
        FT_NOT_SUPPORTED,
        FT_OTHER_ERROR,
        FT_DEVICE_LIST_NOT_READY,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct FT_DEVICE_INFO_NODE
    {
        public UInt32 Flags;
        public UInt32 Type;
        public UInt32 ID;
        public UInt32 LocId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string SerialNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string Description;
        public IntPtr ftHandle;
    }



    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct FT_PROGRAM_DATA_V0
    {

        public UInt32 Signature1;       
        public UInt32 Signature2;      
        public UInt32 Version;          
        public UInt16 VendorId;         
        public UInt16 ProductId;       
        
        public IntPtr Manufacturer;    
        public IntPtr ManufacturerId;   
        public IntPtr Description;      
        public IntPtr SerialNumber;     
        
        public UInt16 MaxPower;         
        public UInt16 PnP;              
        public UInt16 SelfPowered;     
        public UInt16 RemoteWakeup;     

        public byte Rev4;              
        public byte IsoIn;             
        public byte IsoOut;            
        public byte PullDownEnable;    
        public byte SerNumEnable;      
        public byte USBVersionEnable;  
        public UInt16 USBVersion;      
    }
}