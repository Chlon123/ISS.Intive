import React, {Component} from 'react';

class Main extends Component{
    constructor(props) {
        super(props);
        
        this.state = {};
    }

    logData(){
        let data = this.props.getSpaceStationData();
        console.log(data)
    }

    render () {
        return (
            <div>
                <button onClick = {() => this.logData()}>
                    Start!
                </button>
            </div>
        )
    }

}

export default Main;