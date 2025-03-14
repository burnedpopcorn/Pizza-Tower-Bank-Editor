using System;

namespace SimpleRIFF;

public struct CharacterCode
{
	private byte[] _data;

	public string Code
	{
		get
		{
			string buf = string.Empty;
			for (int i = 0; i < _data.Length; i++)
			{
				string text = buf;
				char c = (char)_data[i];
				buf = text + c;
			}
			return buf;
		}
		set
		{
			_data[0] = (byte)value[0];
			_data[1] = (byte)value[1];
			_data[2] = (byte)value[2];
			_data[3] = (byte)value[3];
		}
	}

	public CharacterCode()
	{
		_data = new byte[4];
		_data = new byte[4];
	}

	public CharacterCode(byte[] data)
	{
		_data = new byte[4];
		if (data.Length == 4)
		{
			_data = data;
		}
	}

	public override bool Equals(object? obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != typeof(CharacterCode))
		{
			return false;
		}
		if (_data == ((CharacterCode)obj)._data)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(_data, Code);
	}

	public override string ToString()
	{
		return Code;
	}

	public static bool operator ==(CharacterCode left, CharacterCode right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CharacterCode left, CharacterCode right)
	{
		return !(left == right);
	}
}
