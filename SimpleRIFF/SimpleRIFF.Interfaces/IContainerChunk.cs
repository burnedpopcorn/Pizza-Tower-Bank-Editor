namespace SimpleRIFF.Interfaces;

public interface IContainerChunk : IGenericChunk
{
	ChunkCollection Children { get; }
}
