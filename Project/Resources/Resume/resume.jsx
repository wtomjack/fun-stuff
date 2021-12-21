
class Resume extends React.Component {

    render() {
        return (
                <div className="modal is-active">
                    <div className="modal-background"></div>
                    <div className="modal-content">
                        <section className="section has-text-centered">
                            <div className="card" style={{ background: "url('/Resources/Resume/motoresumebackground.jpg') no-repeat center center fixed" }}>
                                <div className="card-content">
                                    <nav className="level">
                                        <div className="level-item has-text-centered">
                                            <figure className="image is-128x128">
                                                <img className='is-rounded center center fixed' src={"Resources/Resume/ResumePhoto.jpg"} alt="Placeholder image"></img>
                                            </figure>

                                        </div>
                                    </nav>

                                    <h1 className="title has-text-weight-normal is-size-3 inline__padding">Wesley Tomjack</h1>
                                    <p className="is-size-5">Software Engineer</p>
                                <p className="is-size-6">Lover of whiskey and all things house music. Find me on the weekends riding a motorcycle or hiking a mountain.</p>
                                <br />
                                    <p className="is-size-7">"Don't take life too seriously, nobody makes it out alive"</p>
                                </div>
                            </div>

                        </section>
                    </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('resumeContent').style.display = 'none';}}></button>
                </div>
        );
    }

}


ReactDOM.render(<Resume />, document.getElementById('resumeContent'));