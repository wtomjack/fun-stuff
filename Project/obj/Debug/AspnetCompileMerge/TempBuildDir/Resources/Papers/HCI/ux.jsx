
class UX extends React.Component {

    render() {
        return (
            <div className="modal is-active">
                <div className="modal-background"></div>
                <div className="modal-content">
                    <section className="section has-text-centered">
                        <div className="card" style={{ background: "url('/Resources/WeatherComponent/WeatherIcons/weatherBackground.jpg') no-repeat center center fixed" }}>
                            <div className="card-content">
                                <div className="media">
                                    <div className="media-content">
                                        <ul className="menu-list">
                                            <li><a href="/Resources/Papers/HCI/SportsStadiumAppDesign.pdf">Sports Stadium App Design</a></li>
                                            <li><a href="/Resources/Papers/HCI/HBOGoHeuristicEvaluation.pdf">HBO Go Heuristic Evaluation and Redesign</a></li>
                                            <li><a href="/Resources/Papers/HCI/AssignmentP1.pdf">Assignment P1</a></li>
                                            <li><a href="/Resources/Papers/HCI/AssignmentP2.pdf">Assignment P2</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('uxContent').style.display = 'none'; }}></button>
            </div>

        );
    }

}


ReactDOM.render(<UX />, document.getElementById('uxContent'));