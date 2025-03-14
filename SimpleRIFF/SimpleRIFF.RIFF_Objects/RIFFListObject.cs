using System;
using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;

namespace SimpleRIFF.RIFF_Objects;

public class RIFFListObject : IContainerChunk, IGenericChunk
{
	public ChunkCollection Children { get; private set; }

	public IContainerChunk? Parent { get; internal set; }

	public CharacterCode CharacterCode { get; private set; }

	public CharacterCode ListType { get; private set; }

	public RIFFListObject(IContainerChunk parent)
	{
		Children = new ChunkCollection(this);
		Parent = parent;
	}

	public void Read(RIFFStream baseStream)
	{
		CharacterCode = baseStream.ReadCharacterCode();
		int size = baseStream.ReadInt32();
		long initialReadPosition = baseStream.Position;
		ListType = baseStream.ReadCharacterCode();
		Console.WriteLine($"Starting read at {initialReadPosition.ToString("X")}, expected end is ${(initialReadPosition + size).ToString("X")}, reported size of {size.ToString("X")}");
		while (baseStream.Position < initialReadPosition + size)
		{
			if (baseStream.PeekCharacterCode().Code == "LIST")
			{
				RIFFListObject chunk = new RIFFListObject(this);
				chunk.Read(baseStream);
				Children.Add(chunk);
			}
			else
			{
				RIFFGenericDataObject chunk2 = new RIFFGenericDataObject(this);
				chunk2.Read(baseStream);
				Children.Add(chunk2);
			}
		}
	}
}
