internal class IntArrayList
{
    private int[] _buffer;
    int _elementsCount;
    int _realBufferCapacity;
    private readonly int _defaultBufferCapacity = 2;
    int Count { get { return _elementsCount; } }
    int Capacity { get { return _realBufferCapacity; } }

    public int this[int index] { get { return _buffer[index]; } set { _buffer[index] = value; } }

    IntArrayList()
    {
        _realBufferCapacity = _defaultBufferCapacity;
        _buffer = new int[_realBufferCapacity];
    }

    IntArrayList(int bufferCapacity)
    {
        _realBufferCapacity = bufferCapacity;
        _buffer = new int[_realBufferCapacity];
    }

    void PushBack(int value)
    {
        if (_elementsCount == _realBufferCapacity)
        {
            _realBufferCapacity *= 2;
            int[] newBuffer = new int[_realBufferCapacity];

            for (int i = 0; i < _elementsCount; i++)
            {
                newBuffer[i] = _buffer[i];
            }

            _elementsCount++;
            newBuffer[_elementsCount] = value;

            _buffer = newBuffer;
        }
        else
        {
            _elementsCount++;
            _buffer[_elementsCount] = value;
        }
    }

    void PopBack()
    {
        if (_elementsCount > 0)
        {
            _elementsCount--;
            _buffer[_elementsCount] = 0;
        }
    }

    bool TryInsert(int index, int value)
    {
        if (index >= 0 && index <= _elementsCount)
        {
            if (index == _elementsCount)
            {
                PushBack(value);
            }
            else
            {
                _buffer[index] = value;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    bool TryErase(int index)
    {
        if (index < 0 || index >= _elementsCount)
        {
            return false;
        }
        else
        {
            _buffer[index] = 0;
            _elementsCount--;
            return true;
        }
    }

    bool TryGetAt(int index, out int result)
    {
        if (index < 0 || index >= _elementsCount)
        {
            result = 0;
            return false;
        }
        else
        {
            result = _buffer[index];
            return true;
        }
    }

    public void Clear()
    {
        _elementsCount = 0;
    }

    public bool TryForceCapacity(int newCapacity)
    {
        if (newCapacity < 0)
        {
            return false;
        }
        else
        {
            if (_realBufferCapacity < newCapacity)
            {
                _elementsCount = newCapacity;
            }

            _realBufferCapacity = newCapacity;
            int[] newBuffer = new int[_realBufferCapacity];

            for (int i = 0; i < _elementsCount; i++)
            {
                newBuffer[i] = _buffer[i];
            }

            _buffer = newBuffer;

            return true;
        }
    }

    public int Find(int value)
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            if (_buffer[i] == value)
            {
                return i;
            }
        }

        return -1;
    }
}
