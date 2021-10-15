using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using SQLite;

namespace JTea_DPS926_Assignment2
{
    public class Coin : INotifyPropertyChanged
    {
        // property change event implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // unique id for database access
        [PrimaryKey, AutoIncrement]
        public int unique_id { get; set; }

        // backing fields
        private string _id;

        private string _symbol;

        private string _name;

        private Image _image;

        private MarketData _market_data;

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
        public MarketData market_data
        {
            get
            {
                return _market_data;
            }
            set
            {
                if (value == _market_data)
                {
                    return;
                }

                _market_data = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(market_data)));
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
        public Coin(string id, string symbol, string name, Image image, MarketData market_data, Description description)
        {
            this.id = id;
            this.symbol = symbol;
            this.name = name;
            this.image = image;
            this.market_data = market_data;
            this.description = description;
        }
    }
}

public class Image : INotifyPropertyChanged
{
    // property change event implementation
    public event PropertyChangedEventHandler PropertyChanged;

    // backing fields
    private string _thumb;

    private string _small;

    private string _large;

    // image url string (thumbnail)
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

    // image url string (small)
    public string small
    {
        get
        {
            return _small;
        }
        set
        {
            if (value == _small)
            {
                return;
            }

            _small = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(small)));
            }
        }
    }

    // image url string (large)
    public string large
    {
        get
        {
            return _large;
        }
        set
        {
            if (value == _large)
            {
                return;
            }

            _large = value;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(large)));
            }
        }
    }

    // constructor (1 params required)
    public Image(string thumb, string small, string large)
    {
        this.thumb = thumb;
        this.small = small;
        this.large = large;
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