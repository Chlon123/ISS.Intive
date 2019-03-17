import * as React from 'react';
import './Main.css';
import earth from '../styles/images/earthPlanet.png';
import spaceStation from '../styles/images/iss-image.png';

class Main extends React.Component <any, any> {
  constructor(props) {
    super(props);
    this.state= {velocity: 0, distance: 0 };
  }
  componentDidMount(){
    this.setState({data: this.props.data}, () => console.log(this.state.data))
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.data.velocity !== this.state.velocity) {
      this.setState({ velocity: nextProps.data.velocity });
    }
    if (nextProps.data.distance !== this.state.distance) {
      this.setState({ distance: this.state.distance + nextProps.data.distance });
    }
  }

  getVelocity(){
    var vel = Math.round(this.state.velocity);
    return vel;
  }

  getDistance(){
    var dist = Math.round(this.state.distance/1000)
    return dist;
  }

    public render() {
      return (
        <div className='main-parent' id="#main">
        <div className='mainContentContainer'>
        <div className="animation-wrapper">
        <img src={earth} className='earthImage'id='#earthImage'></img>
        <img src={spaceStation} className='spaceStationImage' id='#spaceStationImage'></img>
        </div>
        <table className='iss-table'>
            <tr>
                <th>iss distance: </th>
                <th>{this.getDistance()}</th>
                <th>km</th>
            </tr>
            <tr>
                <th>iss velocity: </th>
                <th>{this.getVelocity()}</th>
                <th>km/h</th>
            </tr>
        </table>
        </div>
        </div>
      );
    }
  }


export default Main;
