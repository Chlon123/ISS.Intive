   import React, {Component}  from 'react';
   import ReactDOM from 'react-dom';
   import LeftBar from './components/leftBar'
   import Main from './components/main';

   class App extends Component {
        constructor(props){
            super(props);

            this.state = {};
        }

        fetchData = function(){
            const baseUrl = 'http://localhost:59622/start/spacetravel';
            const response1 = fetch(baseUrl)
            .then(response => response.json())
            .then(json => console.log(json))
        }



       render ()    {
        return (
            <div>
                <LeftBar/>
                <Main getSpaceStationData = {() => this.fetchData()}/>
            </div>
           );
       }  
       
   }

   ReactDOM.render(<App />, document.querySelector('.container'));