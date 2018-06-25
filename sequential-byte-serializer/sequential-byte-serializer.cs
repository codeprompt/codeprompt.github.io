using System;
using System.Collections;
using System.IO;

namespace codeprompt.github.io
{
    /* MAP
     
    IOException : Exception

    EntryType : byte
        .Empty
        .UInt16
        .String
        .Boolean
        .Byte
        .Error

    Entry
        .EntryType                              Type
        .object                                 Value

        .()
        .(EntryType, object)					type, value
         
    EntryList
        .[int]                      ->Entry
        .Add(Entry)                 ->int       value

    Reader
        .bool                                   RecordComplete      //wether the current record have been completely red.
        .string                                 Header              //The opened file header.
        .int                                    EntryCount          //The count of all the entries in the current record.
        .bool                                   EndOfFile           //Wether the end of file is reached.

        .Open(string path)
        .Open(BinaryReader reader)
        .Close()

        .GetNextRecord()			->bool
        .RetrieveEntry()			->Entry
        .RetrieveString()			->string
        .RetrieveInt16()			->int
        .RetrieveBoolean()			->bool
        .RetrieveByte()				->byte


    Writer
        .Open(string, string)                   path, header
        .Close()

        .NewRecord()
        .StoreEmpty()
        .StoreBoolean(bool)                     value
        .StoreInt16(int)                        value
        .StoreByte(byte)                        value
        .StoreString(string)                    value
         
         */

    public sealed class SimpleDB
    {
        /// <summary>
        /// Exception class for the system.
        /// </summary>
        public class IOException : Exception
        {
            public IOException(string Message) : base(Message)
            {
            }
            public IOException(string Message, Exception Inner) : base(Message, Inner)
            {
            }
            public IOException(EntryType Type, BinaryReader Reader) : base("Type mismatch in file. Read '" + char.ConvertFromUtf32((int)Type).ToString() + "' at " + Reader.BaseStream.Position.ToString())
            {
            }
        }

        /// <summary>
        /// The type of entry.
        /// </summary>
        public enum EntryType : byte
        {
            Empty = 69,
            UInt16 = 73,
            String = 83,
            Boolean = 66,
            Byte = 98,
            Error = 0
        }

        /// <summary>
        /// An entry. The file consists of records, 
        /// each of which consist of entries.
        /// </summary>
        public class Entry
        {
            public EntryType Type;
            public object Value;

            public Entry()
            {
                Type = EntryType.Empty;
                Value = "";
            }
            public Entry(EntryType type, object value)
            {
                Type = type;
                Value = value;
            }
        }

        /// <summary>
        /// List of entries.
        /// </summary>
        public class EntryList : ArrayList
        {
            public new Entry this[int index]
            {
                get
                {
                    return (Entry)base[index];
                }
                set
                {
                    base[index] = value;
                }
            }

            public EntryList()
            {
            }

            public int Add(Entry value)
            {
                return base.Add(value);
            }
        }

        /// <summary>
        /// Use to read from file.
        /// </summary>
        public class Reader
        {
            const byte kRecordContentMulti = 77;

            BinaryReader _Reader;
            string _FileHeader;
            int _EntryCount;
            int _EntriesRead;


            public Reader()
            {
            }
            ~Reader()
            {
                Close();
            }



            /// <summary>
            /// Wether all the Entries have been red.
            /// </summary>
            public bool RecordComplete
            {
                get
                {
                    return _EntriesRead >= _EntryCount;
                }
            }

            /// <summary>
            /// The opened file header.
            /// </summary>
            /// <returns>The header string.</returns>
            public string Header
            {
                get
                {
                    return _FileHeader;
                }
            }

            /// <summary>
            /// The count of all the entries in the current record.
            /// </summary>
            public int EntryCount
            {
                get
                {
                    return _EntryCount;
                }
            }

            /// <summary>
            /// Wether the end of file is reached.
            /// </summary>
            public bool EndOfFile
            {
                get
                {
                    return _Reader.BaseStream.Position == _Reader.BaseStream.Length;
                }
            }




            /// <summary>
            /// Set underlying file to read from, from a given path.
            /// </summary>
            /// <param name="path">The file-path.</param>
            public void Open(string path)
            {
                try
                {
                    Open(new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read)));
                }
                catch { }
            }

            /// <summary>
            /// Set underlying file to read from, from a given 'BinaryReader'.
            /// </summary>
            /// <param name="reader">A 'BinaryReader' created from the desired path.</param>
            public void Open(BinaryReader reader)
            {
                _Reader = reader;
                _EntryCount = 0;
                _EntriesRead = 0;
                _FileHeader = RawReadCString();
				GetNextRecord();
            }

            /// <summary>
            /// Close the underlying 'BinaryReader'.
            /// </summary>
            public void Close()
            {
                if (_Reader != null)
                {
                    _Reader.Close();
                    _Reader = null;
                }
            }


            /// <summary>
            /// Read an entry.
            /// </summary>
            /// <returns>The retrieved entry.</returns>
            public Entry RetrieveEntry()
            {
                Entry entry = new Entry();
                if (RecordComplete)
                {
                    throw new IOException("Read past end of record at " + _Reader.BaseStream.Position.ToString());
                }

                _EntriesRead++;
                byte b = _Reader.ReadByte();
                entry.Type = (EntryType)b;
				
                if (b == 69)                                   //Empty
                {
                    entry.Value = "";
                }
                else if (b == 66)                              //Boolean
                {
                    byte b3 = _Reader.ReadByte();
                    entry.Value = (b3 == 1);
                }
                else if (b == 73)                              //UInt16
                {
                    entry.Value = RawReadUInt16();
                }
                else if (b == 83)                              //String
                {
                    entry.Value = RawReadCString();
                }
                else if (b == 98)                              //Byte
                {
                    entry.Value = _Reader.ReadByte();
                }
                else
                {
                    entry.Type = EntryType.Error;
                    entry.Value = "";
                }

                return entry;
            }

            /// <summary>
            /// Try to retrieve an entry of string type and cast it '.ToString()' or
            /// throw 'IOException' if not possible.
            /// </summary>
            /// <returns>The entry string.</returns>
            public string RetrieveString()
            {
                Entry entry = RetrieveEntry();

                if (entry.Type == EntryType.String)
                {
                    return entry.Value.ToString();
                }
                throw new IOException(entry.Type, _Reader);
            }

            /// <summary>
            /// Try to retrieve an entry of UInt16 type and cast it to 'Int32' or
            /// throw 'IOException' if not possible.
            /// </summary>
            /// <returns>The int entry.</returns>
            public int RetrieveInt16()
            {
                Entry entry = this.RetrieveEntry();
                if (entry.Type == EntryType.UInt16)
                {
                    return Convert.ToInt32(entry.Value);
                }
                throw new IOException(entry.Type, _Reader);
            }

            /// <summary>
            /// Try to retrieve an entry of Boolean type and cast it to 'bool' or
            /// throw 'IOException' if not possible.
            /// </summary>
            /// <returns>The bool entry.</returns>
            public bool RetrieveBoolean()
            {
                Entry entry = RetrieveEntry();
                if (entry.Type == EntryType.Boolean)
                {
                    return Convert.ToBoolean(entry.Value);
                }
                throw new IOException(entry.Type, _Reader);
            }

            /// <summary>
            /// Try to retrieve an entry of Boolean type and cast it to 'byte' or
            /// throw 'IOException' if not possible.
            /// </summary>
            /// <returns>The byte entry.</returns>
            public byte RetrieveByte()
            {
                Entry entry = RetrieveEntry();
                if (entry.Type == EntryType.Byte)
                {
                    return Convert.ToByte(entry.Value);
                }
                throw new IOException(entry.Type, _Reader);
            }

            /// <summary>
            /// Read until the end of the current record and get next byte,
            /// which should be the constant 'kRecordContentMulti' or 77.
            /// </summary>
            /// <returns>True is successfull.</returns>
            public bool GetNextRecord()
            {
                while (_EntriesRead < _EntryCount)
                {
                    RetrieveEntry();
                }
                byte b = _Reader.ReadByte();

                if (b == 77)                                    //kRecordContentMulti
                {
                    _EntryCount = RawReadUInt16();
                    _EntriesRead = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }




            /// <summary>
            /// Read 2 bytes and return those as ushort.
            /// </summary>
            /// <returns></returns>
            ushort RawReadUInt16()
            {
                int num = _Reader.ReadByte();
                int num2 = _Reader.ReadByte();
                return (ushort)((num2 << 8) + num);
            }

            /// <summary>
            /// Read a null terminated string.
            /// </summary>
            string RawReadCString()
            {
                string text = "";
                bool flag = false;
                while (!flag)
                {
                    ushort num = RawReadUInt16();
                    if (num == 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        text += Convert.ToString(char.ConvertFromUtf32(num));
                    }
                }
                return text;
            }
        }

        /// <summary>
        /// Used to write to file.
        /// </summary>
        public class Writer
        {
            FileStream _File;
            BinaryWriter _Writer;
            EntryList _CurrentRecord;


            /// <summary>
            /// Ctor.
            /// </summary>
            public Writer()
            {
                _CurrentRecord = new EntryList();
            }
            ~Writer()
            {
                Close();
            }


            /// <summary>
            /// Close the writer.
            /// </summary>
            public void Close()
            {
                WriteRecord();
                _File.Close();
            }

            /// <summary>
            /// Create file to write to and open the writer.
            /// </summary>
            /// <param name="path"></param>
            /// <param name="header"></param>
            public void Open(string path, string header)
            {
                try
                {
                    _File = new FileStream(path, FileMode.Create);
                    _Writer = new BinaryWriter(_File);
                    RawWriteCString(header);
                }
                catch (Exception ex)
                {
                    throw new IOException("Could not open file", ex);
                }
            }


            /// <summary>
            /// Add new Entry of "EntryType.Empty" to the current record.
            /// </summary>
            public void StoreEmpty()
            {
                _CurrentRecord.Add(new Entry(EntryType.Empty, ""));
            }

            /// <summary>
            /// Add new Entry of "EntryType.Boolean" to the current record.
            /// </summary>
            /// <param name="value">The entry value.</param>
            public void StoreBoolean(bool value)
            {
                _CurrentRecord.Add(new Entry(EntryType.Boolean, value));
            }

            /// <summary>
            /// Add new Entry of "EntryType.UInt16" to the current record.
            /// </summary>
            /// <param name="value">The entry value.</param>
            public void StoreInt16(int value)
            {
                _CurrentRecord.Add(new Entry(EntryType.UInt16, value));
            }

            /// <summary>
            /// Add new Entry of "EntryType.Byte" to the current record.
            /// </summary>
            /// <param name="value">The entry value.</param>
            public void StoreByte(byte value)
            {
                _CurrentRecord.Add(new Entry(EntryType.Byte, value));
            }

            /// <summary>
            /// Add new Entry of "EntryType.String" to the current record.
            /// </summary>
            /// <param name="value">The entry value.</param>
            public void StoreString(string value)
            {
                _CurrentRecord.Add(new Entry(EntryType.String, value));
            }

            void RawWriteCString(string text)
            {
                for(int i = 0; i < text.Length; i++)
                {
                    RawWriteInt16(text[i]);
                }
                RawWriteInt16(0);
            }
            void RawWriteInt16(int value)
            {
                byte a = (byte)(value & 255);
                byte b = (byte)(value >> 8 & 255);
                _Writer.Write(a);
                _Writer.Write(b);
            }
            void RawWriteInt32(int value)
            {
                byte a = (byte)(value & 255);
                byte b = (byte)(value >> 8 & 255);
                b = (byte)(value >> 16 & 255);
                b = (byte)(value >> 24 & 255);
                _Writer.Write(a);
                _Writer.Write(b);
                _Writer.Write(new byte());
                _Writer.Write(new byte());
            }
            void RawWriteByte(byte value)
            {
                _Writer.Write(value);
            }

            /// <summary>
            /// Start new record, by writing all the entries
            /// of the current record to the file.
            /// </summary>
            public void NewRecord()
            {
                WriteRecord();
            }
            void WriteRecord()
            {
                if (_CurrentRecord.Count >= 1)
                {
                    RawWriteByte(77);
                    RawWriteInt16(_CurrentRecord.Count);

                    for(int i = 0; i < _CurrentRecord.Count; i++)
                    {
                        Entry entry = _CurrentRecord[i];
                        EntryType type = entry.Type;
                        if (type == EntryType.Boolean)
                        {
                            RawWriteByte(66);
                            RawWriteByte(Convert.ToByte(Convert.ToBoolean(entry.Value) ? 1 : 0));
                        }
                        else if (type == EntryType.Byte)
                        {
                            RawWriteByte(98);
                            RawWriteByte(Convert.ToByte(entry.Value));
                        }
                        else if (type == EntryType.String)
                        {
                            RawWriteByte(83);
                            string value = Convert.ToString(entry.Value);
                            RawWriteCString(value);
                        }
                        else if (type == EntryType.UInt16)
                        {
                            RawWriteByte(73);
                            RawWriteInt16(Convert.ToInt32(entry.Value));
                        }
                        else
                        {
                            RawWriteByte(69);
                        }
                    }
                    _CurrentRecord.Clear();
                }
            }
        }
    }
}
