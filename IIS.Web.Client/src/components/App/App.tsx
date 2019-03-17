import * as React from 'react';
import Header from './Header/Header';
import Footer from './Footer/Footer';
import Main from './Main/Main';
import './App.css';
import axios from 'axios';
import WebStart from './WebStart/WebStart';


class App extends React.Component <any, any> {
  constructor(props) {
    super(props); 
   this.state = {data: {}};
    }

    getISSData(){
      axios.get('http://isswebrestapi.azurewebsites.net/start/spacetravel')
      .then(res => {this.setState({data: res.data}, () => console.log(this.state.data))
        })};

    getSpaceData(){
      setInterval(() => this.getISSData(), 5000);
    }

  public render() {
    return (
      <div className='appContainer'>
      <Header/>
      <WebStart getData = { () => this.getSpaceData()}/>
      <Main data={this.state.data}/>
      <Footer/>
      </div>
    );
  }
}

export default App;
