
class Weather extends React.Component {

    constructor() {
        super();
        this.state = {
            isHidden: false,
            cityValue: '',
            feelsLikeTemp: initialWeatherData.Temperature.FeelsLikeTemp,
            currentTemp: initialWeatherData.Temperature.CurrentTemp,
            tempMin: initialWeatherData.Temperature.Minimum,
            tempMax: initialWeatherData.Temperature.Max,
            humidity: initialWeatherData.Temperature.Humidity,
            errorState: false

        }
    }


    calculateKelvinToFarenheight = (kTemp) => {
        return Math.floor((kTemp - 273.15) * 9 / 5 + 32)
    }

    submit = () => {
        if (!this.state.errorState) {
            fetch('https://api.openweathermap.org/data/2.5/weather?q=' + this.state.cityValue + '&appid=7d7b91c90ab3a1a9ef45c4ec96aa91f6')
                .then(response => response.json())
                .then(data => this.setState({ feelsLikeTemp: data.main["feels_like"], currentTemp: data.main.temp, tempMin: data.main["temp_min"], tempMax: data.main["temp_max"], humidity: data.main["humidity"] }));
        }
    }

    inputChange = (event) => {

        let res = /^[a-zA-Z]+$/.test(event.target.value);
        if (!res) {
            this.setState({ errorState: true })
        }
        else
        {
            this.setState({ cityValue: event.target.value, errorState:false })
        }
    }


    hide = () => {
        document.getElementById('weatherContent').style.display('none');
    }



    render() {
        return (
            <div className="modal is-active">
                <div className="modal-background"></div>
                <div className="modal-content">
                    <section className="section has-text-centered">
                    <div className="card" style={{ background: "url('/Resources/WeatherComponent/WeatherIcons/weatherBackground.jpg') no-repeat center center fixed" }}>
                        <div className="card-content">
                            <div className="media">
                                    <div className="level-item has-text-centered">
                                        <figure className="image is-128x128">
                                            <img className='is-rounded center center fixed' src={initialWeatherData.imageIcon} alt="Placeholder image"></img>
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
                                    <div className="field">
                                        <div className="control has-icons-left has-icons-right">
                                            <input className= {this.state.errorState ? "input is-danger" : "input"} defaultValue={"Enter City Name"} onChange={this.inputChange.bind(this.state.cityValue)} type="text" />
                                                <span className="icon is-small is-left">
                                                    <i className="fas fa-envelope"></i>
                                                </span>
                                                <span className="icon is-small is-right">
                                                    <i className="fas fa-exclamation-triangle"></i>
                                                </span>
                                        </div>
                                        { this.state.errorState &&
                                            <p className="help is-danger">No special characters/numbers/whitespace</p>}
                                        </div>


                                <div className="buttons is-centered ">
                                    <button className="button" onClick={this.submit}>Submit</button>
                                </div>
                            </div>
                        </div>
                        </div>
                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('weatherContent').style.display = 'none'; }}></button>
            </div>

    );
}
                
}


ReactDOM.render(<Weather />, document.getElementById('weatherContent'));