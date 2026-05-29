import axios from 'axios';
import React, { useEffect, useState } from 'react'
import type { Activity } from '../../types';
import { Grid } from '@mui/material';
import ActivitiesList from './ActivitiesList';
import ActivityDetails from './ActivityDetails';
import ActivityCreateForm from './ActivityCreateForm';

function ActivityDashboard() {

    const [activities, setActivities] = useState<Activity[]>([]);
    const [selectedactivity, setSelectedactivity] = useState<Activity | undefined>(undefined);

  useEffect(() => {

    const controller = new AbortController();
    const signal = controller.signal;

      async function fetchData(): Promise<void> {
        try{

          const response = 
            await axios.get<Activity[]>('https://localhost:7189/api/activities', {signal});

          setActivities(response.data);  
        } catch(err) {
          console.error(err);
        }
          
      }

      fetchData();

      return () => {
        controller.abort();
      }

  }, []);


  function handleView(id: string) {
    setSelectedactivity(activities.find(a => a.id === id));
  }

  function handleCancel() {
    setSelectedactivity(undefined);
  }

  return (
    <Grid container spacing={2}>

        <Grid size={8}>
            <ActivitiesList activities={activities} setSelectedActivity={handleView}/>
        </Grid>

        <Grid size={4}>
            {selectedactivity && <ActivityDetails activity={selectedactivity} handleCancel={handleCancel}/>}
            {!selectedactivity && <ActivityCreateForm/>}
        </Grid>

    </Grid>
  )
}

export default ActivityDashboard