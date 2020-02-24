import Vue from 'vue'
import Component from 'vue-class-component'
import { VNode } from 'vue/types/umd'
import { QTabs, QTab, QTabPanels, QTabPanel } from 'quasar'

const DataTable = Vue.component('DataTable', () => import('@/components/data-table.vue')
  .then((app) => app.default)
)

@Component({
  name: 'Tabs',
  components: {
    QTabs,
    QTab,
    QTabPanels,
    QTabPanel
    // DataTable // : () => import('@/components/data-table.vue'),
  }
})
export default class extends Vue {
  public selectedTab: 'data' | 'chart' = 'data';

  public render (h: VNode): VNode {
    return (
      <div>
        <q-tabs
          align="left"
          v-model={this.selectedTab}
          inline-label
          class="bg-primary text-white shadow-2">
          <q-tab name="data" icon="mail" label="Data" />
          <q-tab name="chart" icon="alarm" label="Chart" />
        </q-tabs>

        <q-tab-panels v-model={this.selectedTab} animated>
          <q-tab-panel name="data" style="padding:0px;">
            <DataTable />
          </q-tab-panel>

          <q-tab-panel name="chart">

          </q-tab-panel>
        </q-tab-panels>
      </div>
    )
  }
}
