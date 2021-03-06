﻿const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const CompressionPlugin = require('compression-webpack-plugin');

const conf = {
	mode: 'development',
	devtool: 'source-map',
	entry: [
		'./index.jsx'
	],
	externals: {
		cheerio: 'window',
		'react/addons': 'react',
		'react/lib/ExecutionEnvironment': 'react',
		'react/lib/ReactContext': 'react',
		'react-d3-core/lib/index': 'react-d3-core',
		'react-d3-basic/lib/index': 'react-d3-basic'
	},
	output: {
		path: path.join(__dirname, '/../Core.Server/bin/Debug/netcoreapp2.1/client'),
		filename: 'bundle.js',
		publicPath: '/'
	},
	stats: {
		children: false
	},
	module: {
		rules: [
			{
				test: /\.html$/,
				use: 'html'
			},
			{
				test: /\.less$/,
				use: ExtractTextPlugin.extract({
					fallback: 'style',
					use: ['css', 'less']
				})
			},
			{
				test: /\.css$/,
				use: ExtractTextPlugin.extract({
					fallback: 'style',
					use: 'css'
				})
			},
			{
				test: /\.js|jsx$/,
				loader: 'babel',
				exclude: /node_modules/,
				query: {
					presets: [
						"@babel/env",
						"@babel/react"
					],
					plugins: [
						"@babel/transform-runtime",
						"@babel/proposal-class-properties",
						"@babel/transform-arrow-functions",
						"@babel/syntax-async-generators",
						"@babel/syntax-dynamic-import"
					]
				}
			},
			{
				test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/,
				use: {
					loader: 'url',
					options: {
						limit: 10000,
						mimetype: 'application/font-woff'
					}
				}
			},
			{
				test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/,
				use: 'file'
			}
		]
	},
	plugins: [
		new webpack.ProvidePlugin({
			$: 'jquery',
			jQuery: 'jquery'
		}),
		new ExtractTextPlugin({
			filename: 'bundle.css',
			allChunks: true
		}),
		new HtmlWebpackPlugin({
			inject: false,
			template: 'index.html',
			filename: 'index.html'
		}),
		new CopyWebpackPlugin([{
			from: 'img',
			to: 'img'
		}], {
			copyUnmodified: false
		}),
		new webpack.LoaderOptionsPlugin({
			minimize: true
		})
	],
	resolve: {
		modules: [
			path.join(__dirname, '/'),
			'node_modules'
		],
		extensions: ['*', '.webpack.js', '.web.js', '.json', '.js', '.jsx', '.react.js']
	},
	resolveLoader: {
		moduleExtensions: ['-loader']
	}
};

module.exports = conf;
