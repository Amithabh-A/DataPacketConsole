namespace Updater;
using Updater.Utils;
using System;
using System.Collections.Generic;
using System.Text;

public class DataPacket
{
    public enum PacketType
    {
        Metadata, // single file
        Differences, // multiple files
        ClientFiles, // multiple files
        Broadcast // multiple files
    }

    public class MixedData
    {
        public FileContent? SingleFile { get; set; }
        public List<FileContent>? MultipleFiles { get; set; }
    }

    private PacketType _packetType;
    private MixedData _mixedData = new MixedData();

    // two types of constructors. 
    public DataPacket(PacketType packetType, FileContent fileContent)
    {
        _packetType = packetType;
        _mixedData.SingleFile = fileContent;
    }

    public DataPacket(PacketType packetType, List<FileContent> fileContents)
    {
        _packetType = packetType;
        _mixedData.MultipleFiles = fileContents;
    }

    public PacketType GetPacketType()
    {
        return _packetType;
    }

    public override string ToString()
    {
        StringBuilder formattedOutput = new StringBuilder();
        formattedOutput.AppendLine($"Packet Type: {_packetType}");

        if (_mixedData.SingleFile != null)
        {
            formattedOutput.AppendLine("Single File:");
            formattedOutput.AppendLine(_mixedData.SingleFile.ToString()); // Assuming FileContent has a ToString method
        }

        if (_mixedData.MultipleFiles != null && _mixedData.MultipleFiles.Count > 0)
        {
            formattedOutput.AppendLine("Multiple Files:");
            foreach (var file in _mixedData.MultipleFiles)
            {
                formattedOutput.AppendLine(file.ToString()); // Assuming FileContent has a ToString method
            }
        }

        return formattedOutput.ToString();
    }
}
