import Vue from 'vue'
import Component from 'vue-class-component'
import { VNode } from 'vue/types/umd'
import { QHeader, QToolbar, QBtn, QToolbarTitle } from 'quasar'

 @Component({
   name: 'Header',
   components: {
     QHeader,
     QToolbar,
     QBtn,
     QToolbarTitle } })
export default class extends Vue {
  public render (h: VNode): VNode {
    return (
      <q-header elevated class="glossy">
        <q-toolbar>
          <q-btn
            flat
            dense
            round
            aria-label="Menu"
            icon="menu" />

          <q-toolbar-title>
          Quasar App
          </q-toolbar-title>

          <div></div>
        </q-toolbar>
      </q-header>

    )
  }
}
