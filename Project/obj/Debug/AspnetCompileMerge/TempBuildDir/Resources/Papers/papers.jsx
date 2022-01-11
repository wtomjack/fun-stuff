
class Papers extends React.Component {

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
                                            <li><a href="/Resources/Papers/UnsupervisedLearningReport.pdf">Unsupervised Learning</a></li>
                                            <li><a href="/Resources/Papers/SupervisedLearningReport.pdf">Supervised Learning</a></li>
                                            <li><a href="/Resources/Papers/ReinforcementLearningReport.pdf">Reinforcement Learning</a></li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('papersContent').style.display = 'none'; }}></button>
            </div>

        );
    }

}


ReactDOM.render(<Papers />, document.getElementById('papersContent'));