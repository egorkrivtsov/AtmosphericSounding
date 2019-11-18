import React from 'react';
import Paper from '@material-ui/core/Paper';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';

// responsible for logic with tabs
export const TabsComponent : React.StatelessComponent = ()=> {
    const [value, setValue] = React.useState(0);
  
    const handleChange = (event: React.ChangeEvent<{}>, newValue: number) => 
    {
        setValue(newValue);
    };
  
    return (
      <Paper square>
        <Tabs
          value={value}
          indicatorColor="primary"
          textColor="primary"
          onChange={handleChange}>
          <Tab label="Raw Data" {...a11yProps(0)} />
          <Tab label="Process Data" {...a11yProps(1)} />
          <Tab label="Charts" {...a11yProps(2)} />
        </Tabs>
        {/* <TabPanel value={value} index={0}>
            Item One
        </TabPanel>
        <TabPanel value={value} index={1}>
            Item Two
        </TabPanel>
        <TabPanel value={value} index={2}>
            Item Three
        </TabPanel> */}
      </Paper>
    );
  }

  function a11yProps(index: any) {
    return {
      id: `simple-tab-${index}`,
      'aria-controls': `simple-tabpanel-${index}`,
    };
  }