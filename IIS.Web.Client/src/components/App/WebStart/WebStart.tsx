import * as React from 'react';
import './WebStart.css';
import stationAnimation from "src/components/App/animation.js";



class WebStart extends React.Component <any, any> { 
    constructor(props) {
        super(props);
        this.showMainContent = this.showMainContent.bind(this);
    } 

    public render() {
      return (
        <div className="webStart" onClick={this.showMainContent} id='#button'>
          <button className="startButton">Start!</button>
        </div>
      );
    }

    showMainContent(){
        const button = document.getElementById("#button")!;
        const main = document.getElementById('#main')!;
        const footer = document.getElementById('#footer')!;
        button.style.animation = 'fadeIn-Start 3s ease-out';
        setTimeout(()=>{
          button.classList.add('hide');
          main.style.animation = 'fadeOut-Main 4s ease-out';
          footer.style.animation = 'fadeOut-Main 4s ease-out';
          main.classList.add('show');
          footer.classList.add('show');
          stationAnimation();
          this.props.getData();
        }, 2900);

    }


  }

  export default WebStart;