namespace Updater;
using System;
using System.Collections.Generic;
using System.Text;

public class FileContent
{
    public string? FileName { get; set; }
    public string? SerializedContent { get; set; }

    public FileContent(string? fileName, string? serializedContent)
    {
        FileName = fileName;
        SerializedContent = serializedContent;
    }

    public override string ToString()
    {
        return $"FileName: {FileName ?? "N/A"}, Content Length: {SerializedContent?.Length ?? 0}";
    }
}


public class FileMetadata
{
    public string? FileName { get; set; }
    public string? FileHash { get; set; }

    public override string ToString()
    {
        return $"FileName: {FileName ?? "N/A"}, FileHash: {FileHash ?? "N/A"}";
    }
}


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

    public void SetPacketType(PacketType packetType)
    {
        _packetType = packetType;
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

