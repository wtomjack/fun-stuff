
class Resume extends React.Component {

    constructor() {
        super();
        this.state = {
            shouldDisplay: false

        }
    }

    open = () => {
        this.setState({ shouldDisplay: true });
    }

    render() {
        return (
            <div>{this.state.shouldDisplay ?
                <div className="modal is-active">
                    <div className="modal-background"></div>
                    <div className="modal-content">
                        <section className="section has-text-centered">
                            <div className="card" style={{ background: "url('/Resources/Resume/motoresumebackground.jpg') no-repeat center center fixed" }}>
                                <div className="card-content">
                                    <nav class="level">
                                        <div class="level-item has-text-centered">
                                            <figure className="image is-128x128">
                                                <img className='is-rounded center center fixed' src={"Resources/Resume/ResumePhoto.jpg"} alt="Placeholder image"></img>
                                            </figure>

                                        </div>
                                    </nav>

                                    <h1 className="title has-text-weight-normal is-size-3 inline__padding">Wesley Tomjack</h1>
                                    <p className="is-size-4">Software Engineer</p>

                                    <p>
                                        <a href="/" className="title has-text-weight-normal has-text-link is-size-6 resume__label">Resume</a>
                                    </p>
                                    <p>
                                        <a href="/" className="title has-text-weight-normal has-text-link is-size-6 resume__label">AI/ML Papers</a>
                                    </p>
                                    <p className="is-size-7">"Don't take life too seriously, nobody makes it out alive"</p>
                                </div>
                            </div>

                        </section>
                    </div>
                    <button className="modal-close is-large" aria-label="close" onClick={() => { this.setState({shouldDisplay : false}) }}></button>
                </div>
                :
                <button className="button" style={{ backgroundColor: '#87ceeb', fontWeight: 700 }} onClick={this.open}>Profile</button>
            }
                </div>
        );
    }

}


ReactDOM.render(<Resume />, document.getElementById('resumeContent'));