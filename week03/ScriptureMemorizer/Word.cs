public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text, bool visibility = true)
    {
        this._text = text;
        this._isHidden = !visibility;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetWordText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}

