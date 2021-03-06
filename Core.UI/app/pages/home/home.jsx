﻿import React from 'react';
import { Button } from 'react-bootstrap';
import _ from 'lodash';
import Navigation from '../../pages/layout/navigation/navigation';
import Adventures from '../../components/adventures/adventures';
import Experiences from '../../components/experiences/experiences';
import './home.less';

class Home extends React.Component {
	constructor(props) {
		super(props);

		const { adventures, authorizationData } = props;

		this.getNavigationItems = this.getNavigationItems.bind(this);

		const data = {
			adventures,
			authorizationData
		};

		this.state = {
			navigationItems: this.getNavigationItems(data)
		};
	}

	getNavigationItems(data) {
		const { adventures, authorizationData } = data;

		return [
			{
				name: "adventures",
				title: "Adventures",
				icon: "th-list",
				component: <Adventures
					adventures={adventures}
					authorizationData={authorizationData}
					onCreate={this.props.onCreate}
					onUpdate={this.props.onUpdate}
					onRemove={this.props.onRemove}
				/>
			},
			{
				name: "experiences",
				title: "Experiences",
				icon: "tasks",
				component: <Experiences />
			}
		];
	}

	UNSAFE_componentWillReceiveProps(nextProps) {
		const { adventures, authorizationData } = nextProps;
		const data = { adventures, authorizationData };

		const navigationItems = this.getNavigationItems(data);

		this.setState({
			navigationItems: navigationItems
		});
	}

	componentWillMount() {
		const { onGetAll } = this.props;
		onGetAll();
	}

	render() {
		const { navigationItems } = this.state;
		const active = _.first(navigationItems);

		return (
			<div className="home">
				<Navigation
					items={navigationItems}
					active={active}
				/>
			</div>
		);
	}
}

export default Home;