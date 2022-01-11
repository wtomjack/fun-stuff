
class Ethics extends React.Component {

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
                                            <li><a href="/Resources/Papers/Ethics/FairnessBiasStudy.pdf">Fairness/Bias Study</a></li>
                                            <li><a href="/Resources/Papers/Ethics/MentalHealthFairnessAndBias.docx">Mental Health Fairness Bias Study</a></li>
                                            <li><a href="/Resources/Papers/Ethics/MachineLearningBias.pdf">Machine Learning Bias</a></li>
                                            <li><a href="/Resources/Papers/Ethics/StudentPerformanceDisparateImpactStudy.pdf">Student Performance Disparate Impact Study</a></li>
                                            <li><a href="/Resources/Papers/Ethics/GenderSpecificPhraseStudy.pdf">Gender Specific Phrase Study</a></li>

                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('ethicsContent').style.display = 'none'; }}></button>
            </div>

        );
    }

}


ReactDOM.render(<Ethics />, document.getElementById('ethicsContent'));