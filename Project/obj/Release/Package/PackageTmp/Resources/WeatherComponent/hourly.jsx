        let hourlyWeather = initialData.Weather.Hours.map((item, key) => 
            <a className="panel-block" style={hourlyStyle}>
                <img className="panel-icon" src={item.IconImage} style={iconStyle}></img>
                <p className="is-family-primary has-text-white"><b>&emsp;{item.Hour}</b></p>
                <p className="is-family-primary has-text-white"><b> &nbsp;&nbsp;&nbsp;&nbsp;{item.Temperature.Value}&nbsp;{item.Temperature.Unit}</b></p>
                <p className="is-family-primary has-text-white"><b>&emsp; &emsp;Chance of Rain:&nbsp;{item.PrecipitationProbability}%</b></p>
            </a>);

        return (
            <nav className="panel" style={backgroundStyle}>
    <p className="panel-heading">
        Weather
    </p>
    <div className="panel-block">
        <p className="control has-icons-left">
           <input className="input" type="text" placeholder="Please Enter Zip Code" />

        </p>
    </div>
    <p className="panel-tabs">
        <a>Hourly Forecast</a>
        <a>Current Forecast</a>
        <a>5 Day Forecast</a>
    </p>
        {hourlyWeather}
        </nav>
                    );