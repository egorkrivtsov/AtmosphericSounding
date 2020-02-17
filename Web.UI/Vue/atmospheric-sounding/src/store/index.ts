import Vue from 'vue'
import Vuex from 'vuex'
import DataModule, { ModuleName as DataModuleName } from './data-store'
import { getModule } from 'vuex-module-decorators'

Vue.use(Vuex)

const store = new Vuex.Store({
  // state: {
  // },
  // mutations: {
  // },
  // actions: {
  // },
  modules: {
    [DataModuleName]: DataModule
  }
})

export const dataStore = getModule(DataModule, store)

export default store
