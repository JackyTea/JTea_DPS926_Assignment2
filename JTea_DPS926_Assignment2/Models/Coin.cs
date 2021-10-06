using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JTea_DPS926_Assignment2
{
    public class Coin : INotifyPropertyChanged
    {
        // property change event implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // backing fields
        private string _id;

        private string _symbol;

        private string _name;

        private Image _image;

        private MarketData _price;

        private Description _description;

        // id of the cryptocurrency
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == _id)
                {
                    return;
                }

                _id = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(id)));
                }
            }
        }

        // market ticker of the cryptocurrency
        public string symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                if (value == _symbol)
                {
                    return;
                }

                _symbol = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(symbol)));
                }
            }
        }

        // name of the cryptocurrency
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == _name)
                {
                    return;
                }

                _name = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(name)));
                }
            }
        }

        // logo url of the cryptocurrency
        public Image image
        {
            get
            {
                return _image;
            }
            set
            {
                if (value == _image)
                {
                    return;
                }

                _image = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(image)));
                }
            }
        }

        // current price of the cryptocurrency (in USD)
        public MarketData price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value == _price)
                {
                    return;
                }

                _price = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(price)));
                }
            }
        }

        // description of the cryptocurrency
        public Description description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value == _description)
                {
                    return;
                }

                _description = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(description)));
                }
            }
        }

        // default constructor (0 params required)
        public Coin() { }

        // constructor (6 params required)
        public Coin(string id, string symbol, string name, Image image, MarketData price, Description description)
        {
            this.id = id;
            this.symbol = symbol;
            this.name = name;
            this.image = image;
            this.price = price;
            this.description = description;
        }
    }
}

public class Image : INotifyPropertyChanged
{
    // property change event implementation
    public event PropertyChangedEventHandler PropertyChanged;

    // backing field
    private string _thumb;

    // image url string
    public string thumb
    {
        get
        {
            return _thumb;
        }
        set
        {
            if (value == _thumb)
            {
                return;
            }

            _thumb = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(thumb)));
            }
        }
    }

    // constructor (1 params required)
    public Image(string thumb)
    {
        this.thumb = thumb;
    }
}

public class CurrentPrice : INotifyPropertyChanged
{
    // property change event implementation
    public event PropertyChangedEventHandler PropertyChanged;

    // backing field
    private double _usd;

    // price in usd currency
    public double usd
    {
        get
        {
            return _usd;
        }
        set
        {
            if (value == _usd)
            {
                return;
            }

            _usd = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(usd)));
            }
        }
    }

    // constructor (1 params required)
    public CurrentPrice(double usd)
    {
        this.usd = usd;
    }
}

public class MarketData : INotifyPropertyChanged
{
    // property change event implementation
    public event PropertyChangedEventHandler PropertyChanged;

    // backing field
    private CurrentPrice _current_price;

    // current price nested json property
    public CurrentPrice current_price
    {
        get
        {
            return _current_price;
        }
        set
        {
            if (value == _current_price)
            {
                return;
            }

            _current_price = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(current_price)));
            }
        }
    }

    // constructor (1 params required)
    public MarketData(CurrentPrice current_price)
    {
        this.current_price = current_price;
    }
}

public class Description : INotifyPropertyChanged
{
    // property change event implementation
    public event PropertyChangedEventHandler PropertyChanged;

    // backing field
    private string _en;

    // description in english localization
    public string en
    {
        get
        {
            return _en;
        }
        set
        {
            if (value == _en)
            {
                return;
            }

            _en = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(en)));
            }
        }
    }

    // constructor (1 params required)
    public Description(string en)
    {
        this.en = en;
    }
}