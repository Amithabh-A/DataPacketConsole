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

    private PacketType _packetType;
    private List<FileContent>? _fileContentList;

    // Constructor for multiple files.
    public DataPacket(PacketType packetType, List<FileContent> fileContents)
    {
        _packetType = packetType;
        _fileContentList = fileContents;
    }

    public PacketType GetPacketType()
    {
        return _packetType;
    }

    public List<FileContent> GetFileContentList()
    {
        if (_fileContentList == null)
        {
            throw new InvalidOperationException("File content list is null.");
        }
        return _fileContentList;
    }

    public override string ToString()
    {
        StringBuilder formattedOutput = new StringBuilder();
        formattedOutput.AppendLine($"Packet Type: {_packetType}");

        if (_fileContentList != null && _fileContentList.Count > 0)
        {
            formattedOutput.AppendLine("Multiple Files:");
            foreach (FileContent file in _fileContentList)
            {
                formattedOutput.AppendLine(file.ToString()); // Assuming FileContent has a ToString method
            }
        }

        return formattedOutput.ToString();
    }
}

