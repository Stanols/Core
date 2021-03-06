﻿import React from 'react';
import LoginContainer from './pages/login/loginContainer';
import { Switch, Route } from 'react-router-dom';
import HeaderContainer from './pages/layout/header/headerContainer';
import Footer from './pages/layout/footer/footer';
import HomeContainer from './pages/home/homeContainer';
import RegistrationContainer from './pages/registration/registrationContainer';
import SummaryContainer from './pages/summary/summaryContainer';
import { Grid } from 'react-bootstrap';
import PrivateRoute from './pages/layout/navigation/privateRoute/privateRoute';
import '../styles/bootstrap/bootstrap.less';
import '../styles/bootstrap/theme.less';
import './app.less';

class App extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		return (
			<div>
				<HeaderContainer />
				<div className="content">
					<Grid>
						<Switch>
							<Route path="/" exact component={LoginContainer} />
							<Route path="/login" exact component={LoginContainer} />
							<Route path="/registration" exact component={RegistrationContainer} />

							<PrivateRoute path="/home" exact component={HomeContainer} />
							<PrivateRoute path="/summary" exact component={SummaryContainer} />
						</Switch>
					</Grid>
				</div>
				<Footer />
			</div>
		);
	}
}

export default App;
