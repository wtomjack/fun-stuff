class Clock extends React.Component {
    constructor(props) {
        super(props);

        //This declared the state of time at the very beginning
        this.state = {
            time: new Date().toLocaleTimeString()
        }

    }

    //This happens when the component mount and the setInterval function get called with a call back function updateClock()
    componentDidMount() {
        this.intervalID = setInterval(() =>
            this.updateClock(),
            1000
        );
    }

    //This section clears setInterval by calling intervalID so as to optimise memory
    componentWillUnmount() {
        clearInterval(this.intervalID)
    }

    //This function set the state of the time to a new time
    updateClock() {
        this.setState({
            time: new Date().toLocaleTimeString()
        });
    }

    render() {
        return (
            <div className="Time" style={{"height": "500px", "width": "800px", "margin": "auto", "position": "absolute", "top": "0", "left": "0", "bottom": "0", "right": "0", "paddingTop": "70px", "fontFamily": "courier, monospace", "color": "white", "fontSize": "110px"}}>
                <p> {this.state.time}</p>
            </div>

        );
    }
}

ReactDOM.render(<Clock />, document.getElementById('clock'));