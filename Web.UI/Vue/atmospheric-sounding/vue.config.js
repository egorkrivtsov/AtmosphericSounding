// const UglifyJsPlugin = require('uglifyjs-webpack-plugin')
// const CompressionPlugin = require('compression-webpack-plugin')

module.exports = {
  // chainWebpack: config => {
  //   // config.plugins.delete('prefetch')

  //   // and this line
  //   config.plugin('CompressionPlugin').use(CompressionPlugin)
  // },
  configureWebpack: {
    performance: {
      hints: false
    } // ,
    // plugins: [
    //   new UglifyJsPlugin({ uglifyOptions: { ecma: 5, compress: { keep_fnames: true }, warnings: false, mangle: { keep_fnames: true } } })
    // ]
    // ,
    // optimization: {
    //   minimizer: [new UglifyJsPlugin()]
    // }
    /*,
        optimization: {
          splitChunks: {
            minSize: 10000,
            maxSize: 250000
          }
        } */
  },

  lintOnSave: false,

  pluginOptions: {
    quasar: {
      // importStrategy: 'kebab',
      importStrategy: 'manual',
      rtlSupport: false
    }
  },

  transpileDependencies: [
    'quasar',
    'vuex-module-decorators'
  ],

  productionSourceMap: false
}
