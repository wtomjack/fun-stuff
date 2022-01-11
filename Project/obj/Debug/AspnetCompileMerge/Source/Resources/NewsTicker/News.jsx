class News extends React.Component {

    constructor() {
        super();
        this.state = {
            news: initialNewsData
        }
    }


    render() {
        return (
            
            <div className="overflow-hidden">
                <div className="flex -mx-4 img-ticker">
                    <h1 style={{ color: "white", whiteSpace: 'nowrap' }}>{this.state.news} </h1>
    
                </div>
</div>


        );
    }
}


ReactDOM.render(<News />, document.getElementById('newsTicker'));