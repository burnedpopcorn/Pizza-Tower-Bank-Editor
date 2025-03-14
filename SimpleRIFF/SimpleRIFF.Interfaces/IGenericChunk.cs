using SimpleRIFF.Streams;

namespace SimpleRIFF.Interfaces;

public interface IGenericChunk
{
	IContainerChunk? Parent { get; }

	CharacterCode CharacterCode { get; }

	bool IsRIFF => Parent == null && (CharacterCode.Code == "RIFF" || CharacterCode.Code == "RIFX");

	bool IsList => CharacterCode.Code == "LIST";

	void Read(RIFFStream baseStream);
}
