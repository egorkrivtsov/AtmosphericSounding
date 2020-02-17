<template>
  <div>
    <q-table
      class="data-table"
      ref="table"
      :data="rows"
      :columns="columns"
      row-key="index"
      :virtual-scroll = "true"
      :pagination.sync="pagination"
      :rows-per-page-options="[0]"
    />
  </div>
</template>
<script lang="ts">

import Vue from 'vue'
import Component from 'vue-class-component'
import { Watch } from 'vue-property-decorator'
import { QTable } from 'quasar'
import { dataStore } from '@/store'

@Component({
  name: 'DataTable',
  components: { QTable }
})
export default class DataTable extends Vue {
  public get rows (): any[] { return dataStore.rows }

  public get columns (): any[] { return dataStore.columns }

  public pagination: any = { rowsPerPage: 0 };

  $refs!: {
    table: QTable
  }

  public async mounted () {
    await dataStore.loadAll()
  }

  public scrollToEnd () { this.$refs.table.scrollTo(this.rows.length) }
}

</script>

<style lang="scss">
$height-val: 700px;

.data-table {
  /* height or max-height is important */
  // height: $height-val;
  .q-virtual-scroll {
    max-height: $height-val;
  }
  .q-table__top,
  .q-table__bottom,
  thead tr:first-child th /* bg color is important for th; just specify one */
  {
    background-color: #fff;
  }

  thead tr th {
    position: sticky;
    z-index: 1;
  }
  /* this will be the loading indicator */
  thead tr:last-child th {
    /* height of all previous header rows */
    top: 48px;
  }
  thead tr:first-child th {
    top: 0;
  }
}
</style>
