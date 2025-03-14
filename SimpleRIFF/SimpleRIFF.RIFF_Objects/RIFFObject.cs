using SimpleRIFF.Interfaces;
using SimpleRIFF.Streams;

namespace SimpleRIFF.RIFF_Objects;

public class RIFFObject : IContainerChunk, IGenericChunk
{
	public ChunkCollection Children { get; private set; }

	public IContainerChunk? Parent { get; private set; }

	public CharacterCode CharacterCode { get; private set; }

	public CharacterCode FormType { get; private set; }

	public RIFFObject()
	{
		Children = new ChunkCollection(this);
		Parent = null;
	}

	public void Read(RIFFStream baseStream)
	{
		CharacterCode = baseStream.ReadCharacterCode();
		int size = baseStream.ReadInt32();
		long initialReadPosition = baseStream.Position;
		FormType = baseStream.ReadCharacterCode();
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
