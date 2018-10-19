const path = require('path');
const htmlWebpackPlugin = require('html-webpack-plugin')
require("babel-register");

const config = {
  entry: './js/main.js',
  output: {
    path: path.join(__dirname, './build'),
    filename: 'bundle.js',
  },
  watch: true,
  watchOptions: {
    ignored: /node_modules/,
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: ['babel-loader'],
        // query: {
        //   presets: ['es2015'],
        // },
      },
      {
        test: /\.scss$/,
        use: ['style-loader', 'sass-loader'],
      },
    ],
  },
  plugins: [
    new htmlWebpackPlugin({
      template: './index.html',
      filename: './index.html',
      hash: true,
    }),

  ],
};

module.exports = config;
