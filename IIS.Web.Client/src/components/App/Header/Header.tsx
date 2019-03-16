import * as React from 'react';
import './Header.css';


class Header extends React.Component {
    public render() {
      return (
        <div className="header">
          <header className="header-header">
            <h1 className="header-title">Welcome to iss tracking website!</h1>
          </header>
        </div>
      );
    }
  }

  export default Header;