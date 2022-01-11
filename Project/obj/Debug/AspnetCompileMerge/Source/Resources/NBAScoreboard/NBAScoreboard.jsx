
class NBA extends React.Component {

    constructor() {
        super();

        let newDate = new Date()
        let date = newDate.getDate();
        let month = newDate.getMonth() + 1;
        let year = newDate.getFullYear();

        this.state = {
            games: "",
            date: year + "-" + month +"-" + date
        }
    }

    componentDidMount() {
        fetch("https://api-nba-v1.p.rapidapi.com/games/date/" + this.state.date, {
            "method": "GET",
            "headers": {
                "x-rapidapi-host": "api-nba-v1.p.rapidapi.com",
                "x-rapidapi-key": "d719cb1efamsh65a07c27581f0fdp1335abjsndda303ac9102"
            }
        })
            .then(response => response.json())
            .then(data => this.map(data))
            .catch(err => {
                console.error(err);
            });
    }

    inputChange = (event) => {
        this.setState({ date: event.target.value })
        console.log(this.state.date)
    }

    submit = () => {
        fetch("https://api-nba-v1.p.rapidapi.com/games/date/" + this.state.date, {
            "method": "GET",
            "headers": {
                "x-rapidapi-host": "api-nba-v1.p.rapidapi.com",
                "x-rapidapi-key": "d719cb1efamsh65a07c27581f0fdp1335abjsndda303ac9102"
            }
        })
            .then(response => response.json())
            .then(data => this.map(data))
            .catch(err => {
                console.error(err);
            });
    }

    map = (data) => {
        console.log(data.api.games);
        this.setState({ games: data.api.games });
    }

    render() {
        return (
            <div className="modal is-active">
                <div className="modal-background"></div>
                <div className="modal-content">
                    <section className="section has-text-centered">
                        <div className="card image is-256x256" style={{ background: "url('/Resources/NBAScoreboard/Background.jpg')  center center fixed" }}>
                            <div className="card-content">
                                <div className="media">
                                    <div className="media-content">
                                        {this.state.games && this.state.games.map((item, i) =>
                                            <p className = "has-text-black">{item.vTeam.nickName + " " + item.vTeam.score.points + " @ " + item.hTeam.nickName + " " + item.hTeam.score.points} </p>

                                        )}
                                       
                                    </div>
                                    <div className="content">
                                        <input id="weatherInput" className="input is-primary m-1" onChange={this.inputChange} type="date" />
                                        <div className="buttons is-centered ">
                                            <button className="button" onClick={this.submit}>Submit</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('nbaContent').style.display = 'none'; }}></button>
            </div>

        );
    }

}


ReactDOM.render(<NBA />, document.getElementById('nbaContent'));
