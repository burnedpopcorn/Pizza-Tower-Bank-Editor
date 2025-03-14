using System;
using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;

namespace SimpleRIFF.RIFF_Objects;

public class RIFFGenericDataObject : IDataChunk, IGenericChunk
{
	public IContainerChunk? Parent { get; internal set; }

	public CharacterCode CharacterCode { get; set; }

	public byte[] Data { get; set; } = Array.Empty<byte>();

	public RIFFGenericDataObject(IContainerChunk parent)
	{
		Parent = parent;
	}

	public void Read(RIFFStream baseStream)
	{
		CharacterCode = baseStream.ReadCharacterCode();
		int size = baseStream.ReadInt32();
		Data = new byte[size];
		baseStream.Read(Data, 0, size);
		if (size % 2 != 0)
		{
			baseStream.Position++;
		}
	}
}
