import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';


class App extends Component {
	
	getRealtyByType(type) {
		console.log(type);
		//this.setState(prevState => ({  isToggleOn: !prevState.isToggleOn}));
		}

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to russian realty site</h1>
        </header>
        <p className="App-intro">
          To get started, pick realty type.
        </p>		
			<button onClick={this.getRealtyByType.bind(this, 0)} type="button" className="btn btn-primary mr-md-3">Houses</button>
			<button onClick={this.getRealtyByType.bind(this, 1)} type="button" className="btn btn-primary mr-md-3">Appartments</button>
			<button onClick={this.getRealtyByType.bind(this, 2)} type="button" className="btn btn-primary mr-md-3">Commercial</button>		
		<div>
			<img src={require('./imgs/house1.jpg')} alt="..." className="img-rounded" />
		</div>
      </div>
    );
  }
}

export default App;
