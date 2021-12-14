
class Weather extends React.Component {

    constructor() {
        super();
        this.state = {
            isHidden: false,
            cityValue: '',
            feelsLikeTemp: initialWeatherData.Temperature.FeelsLikeTemp,
            currentTemp: initialWeatherData.Temperature.CurrentTemp,
            tempMin: initialWeatherData.Temperature.Min,
            tempMax: initialWeatherData.Temperature.Max,
            humidity: initialWeatherData.Temperature.Humidity

        }
    }


    calculateKelvinToFarenheight = (kTemp) => {
        return Math.floor((kTemp - 273.15) * 9 / 5 + 32)
    }

    submit = () => {
        fetch('https://api.openweathermap.org/data/2.5/weather?q=' + this.state.cityValue + '&appid=7d7b91c90ab3a1a9ef45c4ec96aa91f6')
            .then(response => response.json())
            .then(data => this.setState({ feelsLikeTemp: data.main["feels_like"], currentTemp: data.main.temp, tempMin: data.main["temp_min"], tempMax: data.main["temp_max"], humidity: data.main["humidity"] }));
    }

    inputChange = (event) => {
        this.setState({ cityValue: event.target.value })
    }

    open = () => {
        this.setState({ isHidden: false });
    }

    hide = () => {
        this.setState({ isHidden: true });
    }



    render() {
        return (
        <div>
    {!this.state.isHidden
        ? <div className="card">
               <div className="card-content">
                    <div className="media">
                    <div className="media-left">
                        <figure className="image is-48x48">
                            <img src={initialWeatherData.imageIcon} alt="Placeholder image"></img>
                        </figure>
                    </div>
                    <div className="media-content">
                        <p className="title is-4">Temperature: {this.calculateKelvinToFarenheight(this.state.currentTemp)} <span>&deg;F</span></p>
                        <p className="subtitle is-6">
                            Feels Like: {this.calculateKelvinToFarenheight(this.state.feelsLikeTemp)} <span>&deg;F</span> <br />
                            Minimum: {this.calculateKelvinToFarenheight(this.state.tempMin)} <span>&deg;F</span> <br />
                            Maximum: {this.calculateKelvinToFarenheight(this.state.tempMax)} <span>&deg;F</span> <br />
                            Humidity: {this.state.humidity} <br />
                        </p>
                    </div>
                </div>

                            <div className="content">
                                <input id="weatherInput" className="input is-primary m-1" defaultValue={this.state.cityValue} onChange={this.inputChange.bind(this.state.cityValue)} type = "text" />
                    <div className="buttons are-small is-centered m-0">
                        <button className="button" onClick={this.hide}>Hide</button>
                        <button className="button" onClick={this.submit}>Submit</button>
                    </div>
                </div>
            </div>
        </div>
        : <button className="button" onClick={this.open}>Hide</button>
                }
            </div>

    );
}
                
}


ReactDOM.render(<Weather />, document.getElementById('weatherContent'));