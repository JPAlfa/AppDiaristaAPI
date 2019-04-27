import React, { Component } from 'react';
import {
	StyleSheet,
	View
  } from 'react-native';
import { Container, Header, Content, Button, Text, Item, Label, Input, Form } from 'native-base';
import $ from 'jquery';
import PubSub from 'pubsub-js';
import { declaredPredicate } from '@babel/types';

export default class ProductAdd extends Component {
	constructor() {
		super();    
		this.state = {list : []}; 
	}
	static navigationOptions = {
		title : "Cadastro de produtos",
		headerTintColor: 'black'
	};

	state = {
		docs: []
	};


	render(){
		return(
			<Container>
        <Content>
          <Form onSubmit={this.enviaForm} method="post" style={style.form}>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Titulo</Label>
              <Input value={this.state.descricao} onChange={this.setDescricao} style={style.input} />
            </Item>
            <Item stackedLabel style={style.item}>
              <Label style={style.label}>Descricao</Label>
              <Input value={this.state.pacote} onChange={this.setPacote} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Pacote</Label>
              <Input value={this.state.imagem} onChange={this.setImagem} style={style.input} />
            </Item>
            <Item stackedLabel style={style.item}> 
              <Label style={style.label}>Imagem</Label>
              <Input value={this.state.valor} onChange={this.setValor} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Valor</Label>
              <Input value={this.state.unitario} onChange={this.setUnitario} style={style.input} />
            </Item>
            <Item stackedLabel style={style.item}>
              <Label style={style.label}>Unitario</Label>
              <Input value={this.state.fornecedor} onChange={this.setFornecedor} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Fornecedor</Label>
              <Input value={this.state.gluten} onChange={this.setGluten} style={style.input} />
            </Item>
            <Item stackedLabel style={style.item}>
              <Label style={style.label}>Gluten</Label>
              <Input value={this.state.lowCarb} onChange={this.setLowCarb} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>LowCarb</Label>
              <Input value={this.state.vegano} onChange={this.setVegano} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Vegano</Label>
              <Input value={this.state.porcoes} onChange={this.setPorcoes} style={style.input} />
            </Item>
            <Item stackedLabel last style={style.item}>
              <Label style={style.label}>Porcoes</Label>
              <Input value={this.state.listProduto} onChange={this.setListProduto} style={style.input} />
            </Item>
			<Button light style={style.button}><Text> Light </Text></Button>
			<Button success onPress={()=> Toast.show({
              text: 'Produto criado com sucesso!',
              buttonText: 'Okay'
            })}><Text> Success </Text></Button>
          </Form>
        
			<View>
				<Text>Render Default</Text>
				<FormProduto />
			</View>
        </Content>
      </Container>
			
			);
	}

}


class FormProduto extends Component{
	constructor(){
		super();
		this.state = { idProduto:'', titulo:'', descricao:'', pacote:'', imagem:'', valor:'', unitario:'', fornecedor:'', gluten:'', lowCarb:'', vegano:'', porcoes:'', listProduto:'' };
   		this.enviaForm = this.enviaForm.bind(this);
      this.setidProduto = this.setidProduto.bind(this);
      this.setTitulo = this.setTitulo.bind(this);
      this.setDescricao = this.setDescricao.bind(this);
      this.setPacote = this.setPacote.bind(this);
      this.setImagem = this.setImagem.bind(this);
      this.setValor = this.setValor.bind(this);
      this.setUnitario = this.setUnitario.bind(this);
      this.setFornecedor = this.setFornecedor.bind(this);
      this.setGluten = this.setGluten.bind(this);
      this.setLowCarb = this.setLowCarb.bind(this);
      this.setVegano = this.setVegano.bind(this);
      this.setPorcoes = this.setPorcoes.bind(this);
      this.setListProduto = this.setListProduto.bind(this);
	}

	enviaForm(event){
    		event.preventDefault();    
   			$.ajax({
   			 		url:'localhost:8080',
   			 		contentType:'application/json',
   			 		dataType:'json',
   			 		type:'post',
   			 		data: JSON.stringify({ titulo:this.state.titulo, descricao:this.state.descricao, pacote:this.state.pacote, imagem:this.state.imagem, valor:this.state.valor, unitario:this.state.unitario, fornecedor:this.state.fornecedor, gluten:this.state.gluten, lowCarb:this.state.lowCarb, vegano:this.state.vegano, porcoes:this.state.porcoes, listProduto:this.state.listProduto}), 
   			 		success: function(newList){
   			 		  	PubSub.publish('update-list-produtos',newList);        
   			 		  	this.setState({ titulo:'', descricao:'', pacote:'', imagem:'', valor:'', unitario:'', fornecedor:'', gluten:'', lowCarb:'', vegano:'', porcoes:'', listProduto:''});
   			 		}.bind(this),
   			  		error: function(resposta){
   			    		if(resposta.status === 400) {
   			      		PubSub.publishError(resposta.responseJSON);
   			    	}},
   			  		beforeSend: function(){
   			    		PubSub.publish({});
   			  		}      
   			});
  	}

    setidProduto(event){this.setState({titulo:event.target.value});}
    setTitulo(event){this.setState({titulo:event.target.value});}
    setDescricao(event){this.setState({descricao:event.target.value});}
    setPacote(event){this.setState({pacote:event.target.value});}
    setImagem(event){this.setState({imagem:event.target.value});}
    setValor(event){this.setState({valor:event.target.value});}
    setUnitario(event){this.setState({unitario:event.target.value});}
    setFornecedor(event){this.setState({fornecedor:event.target.value});}
    setGluten(event){this.setState({gluten:event.target.value});}
    setLowCarb(event){this.setState({lowCarb:event.target.value});}
    setVegano(event){this.setState({vegano:event.target.value});}
    setPorcoes(event){this.setState({porcoes:event.target.value});}
    setListProduto(event){this.setState({listProduto:event.target.value});}

	render(){
		return(
				 <Text>FormProduto</Text>

			)
	}

}




const style =  StyleSheet.create({
	container:{
		backgroundColor: "#000"
	},
	form:{
		backgroundColor: "#EEE",
		borderColor: "#DDD",
		borderWidth: 1,
		borderRadius: 3,
		padding: 20
	},
	item:{
		marginTop: 5
	},
	input:{
		height: 1,
		borderRadius: 5,
		backgroundColor: "#FFF",
		marginTop: 2
	}
})

