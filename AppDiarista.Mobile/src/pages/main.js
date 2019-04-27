import React, { Component } from 'react';
import {
	Platform,
	StyleSheet,
	View,
	FlatList,
	TouchableOpacity
  } from 'react-native';
import { Container, Header, Content, Button, Text } from 'native-base';


export default class Main extends Component {
	static navigationOptions = {
		title : "Marmoteca",
		headerTintColor: 'black'
	};



	render(){
		return(
			<View>
				<FlatList/>
				<View style={styles.productContainer}>
					<Text style={styles.productTitle} >Menu principal</Text>
					<Text style={styles.productDescription} >Functions</Text>
					<TouchableOpacity style={styles.productButton}
						onPress={() => {
							this.props.navigation.navigate('Products')
						}}
					>
						<Text style={styles.productButtonText}>
							Listar produtos
						</Text>
					</TouchableOpacity>
					<TouchableOpacity style={styles.productButton}
						onPress={() => {
							this.props.navigation.navigate('ProductAdd')
						}}
					>
						<Text style={styles.productButtonText}>
							Cadastrar produtos
						</Text>
					</TouchableOpacity>
					<TouchableOpacity style={styles.productButton}
						onPress={() => {
							this.props.navigation.navigate('Products')
						}}
					>
						<Text style={styles.productButtonText}>
							Cadastrar usuarios
						</Text>
					</TouchableOpacity>
				</View>
				
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
		borderColor: "#000",
		backgroundColor: "#5667F9",
		justifyContent: 'center',
		alignItems: 'center',
		marginTop: 7
	},
	productButtonText:{
		fontSize: 16,
		color: "#FFF",
		fontWeight: "bold"
	}

});