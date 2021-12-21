
class Settings extends React.Component {

    render() {
        return (
            <div className="modal is-active">
                <div className="modal-background"></div>
                <div className="modal-content">
                    <section className="section has-text-centered">

                        <figure className="image is-16by9">
                            <img src="Resources/Settings/The_Force_Choke.jpg" />
                        </figure>


                    </section>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={() => { document.getElementById('settingsContent').style.display = 'none'; }}></button>
            </div>
        );
    }

}


ReactDOM.render(<Settings />, document.getElementById('settingsContent'));