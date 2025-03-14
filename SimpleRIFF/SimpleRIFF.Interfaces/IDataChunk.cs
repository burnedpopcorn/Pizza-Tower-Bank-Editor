namespace SimpleRIFF.Interfaces;

public interface IDataChunk : IGenericChunk
{
	byte[] Data { get; }
}
