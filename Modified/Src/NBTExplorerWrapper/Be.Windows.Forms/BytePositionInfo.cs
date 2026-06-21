namespace Be.Windows.Forms;

internal struct BytePositionInfo(long index, int characterPosition)
{
	private int _characterPosition = characterPosition;

	private long _index = index;

	public int CharacterPosition => _characterPosition;

	public long Index => _index;
}
