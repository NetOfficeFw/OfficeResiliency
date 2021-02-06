using System;
using System.IO;
using System.Text;

namespace NetOffice.Tools
{
    public class OfficeResiliency
    {
        private static readonly Encoding UTF16LE = Encoding.Unicode;

        public static DisabledItem Parse(byte[] rawData)
        {
            using (var stream = new MemoryStream(rawData))
            using (var reader = new BinaryReader(stream))
            {
                var disabledItemTypeValue = reader.ReadInt32();
                var countData = reader.ReadInt32();
                var countExtraData = reader.ReadInt32();
                var offset = reader.BaseStream.Position;

                var disabledItemType = (DisabledItemType)disabledItemTypeValue;

                var item = new DisabledItem()
                {
                    DisabledItemType = disabledItemType
                };

                switch (disabledItemType)
                {
                    case DisabledItemType.AddInByFilename:
                    case DisabledItemType.AddInByDEPFilename:
                        
                        if (countData > 2)
                        {
                            var moduleBytes = reader.ReadBytes(countData - 2);
                            var module = UTF16LE.GetString(moduleBytes);
                            item.Module = module;
                        }

                        if (countExtraData > 2)
                        {
                            reader.BaseStream.Position = offset + countData;
                            var friendlyNameBytes = reader.ReadBytes(countExtraData - 2);
                            var friendlyName = UTF16LE.GetString(friendlyNameBytes);
                            item.FriendlyName = friendlyName;
                        }
                        break;
                }


                return item;
            }
        }
    }
}
