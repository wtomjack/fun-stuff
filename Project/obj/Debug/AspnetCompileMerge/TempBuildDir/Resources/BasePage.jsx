
class BasePage extends React.Component {


    showComponent = (component) => {
        document.getElementById(component).style.display = 'block';
    }

    render() {
        return (
           <div>
                <aside className="menu">
                    <p className="menu-label has-text-white">
                        General
                    </p>
                    <ul className="menu-list has-text-white">
                        <li><a className="has-text-white" onClick={() => this.showComponent('resumeContent')}>About Me</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('settingsContent')}>Settings</a></li>
                    </ul>
                    <p className="menu-label has-text-white">
                        Apps
                    </p>
                    <ul className="menu-list has-text-white">
                        <li><a className="has-text-white" onClick={() => this.showComponent('weatherContent')}> Weather</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('hangmanContent')}>Hangman</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('nbaContent')}>NBA Scoreboard</a></li>
                    </ul>
                    <p className="menu-label has-text-white">
                        Links
                    </p>
                    <ul className="menu-list">
                        <li><a className="has-text-white" href="https://github.com/wtomjack3" target="_blank">Github</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('papersContent')}>ML/AI Papers</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('ethicsContent')}>Ethics Study's</a></li>
                        <li><a className="has-text-white" onClick={() => this.showComponent('uxContent')}>UX Study's and Papers</a></li>


                    </ul>
                </aside>



            </div>

            )
    }


}

ReactDOM.render(<BasePage />, document.getElementById('basePage'));
