import React, { Component } from 'react';
import {
	Platform,
	StyleSheet,
	View,
	FlatList,
	TouchableOpacity
  } from 'react-native';
import api from '../services/api';
import { Container, Header, Content, Button, Text } from 'native-base';


export default class Product extends Component {
	static navigationOptions = {
		title : "Marmoteca",
		headerTintColor: 'black'
	};

	state = {
		docs: []
	};

	componentDidMount(){
		this.loadProduct();
	};

	loadProduct = async () => {
		const response = await api.get('/Product');
		const { docs } = response.data;
		this.setState({ docs });
	};

	renderItem = ({ item }) => (
		<View style={styles.productContainer}>
			<Text style={styles.productTitle} >{item.title}</Text>
			<Text style={styles.productDescription} >{item.description}</Text>
			<TouchableOpacity style={styles.productButton}
				onPress={() => {
					this.props.navigation.navigate('Product')
				}}
			>
				<Text style={styles.productButtonText}>
					Comprar
				</Text>
			</TouchableOpacity>
		</View>
	)

	render(){
		return(
			<View>
				<FlatList 
				contentContainerStyle={styles.list}
				data={this.state.docs}
				keyExtractor={item =>item._id}
				renderItem={this.renderItem}
				/>
			</View>
			);
	}

}

const styles =  StyleSheet.create({
	container:{
		backgroundColor: "#000"
	},
	list:{
		padding: 20
	},
	productContainer: {
		backgroundColor: "#FFF",
		borderWidth: 1,
		borderColor: "#DDD",
		borderRadius: 5,
		padding: 20,
		marginBottom: 20
	},
	productTitle: {
		fontSize: 18,
		fontWeight: "bold",
		color: "#333"
	},

	productDescription: {
		fontSize: 16,
		color: "#999",
		marginTop: 5,
		lineHeight: 24
	},
	productButton: {
		height: 42,
		borderRadius: 5,
		borderWidth: 2,
		borderColor: "#5667F9",
		backgroundColor: "transparent",
		justifyContent: 'center',
		alignItems: 'center',
		marginTop: 5
	},
	productButtonText:{
		fontSize: 16,
		color: "#5667F9",
		fontWeight: "bold"
	}

});

