import React, { useState } from 'react'
import type { Activity } from '../../types';
import { Grid } from '@mui/material';
import ActivitiesList from './ActivitiesList';
import ActivityDetails from './ActivityDetails';
import ActivityForm from './ActivityForm';
import { useActivities } from './useActivities';

function ActivityDashboard() {

    const {activities} = useActivities();
    const [selectedactivity, setSelectedactivity] = useState<Activity | undefined>(undefined);
    const [editMode, setEditMode] = useState<boolean>(false);



  function handleView(id: string) {
    setSelectedactivity(activities?.find(a => a.id === id));
  }

  function handleCancel() {
    setSelectedactivity(undefined);
  }

  function setEditModeOn(){
    setEditMode(true);
  }

  function setEditModeOff(){
    setEditMode(false);
  }

  return (
    <Grid container spacing={2} sx={{ m : 3 }}>

        <Grid size={8}>
            {activities && <ActivitiesList activities={activities} setSelectedActivity={handleView}/>}
        </Grid>

        <Grid size={4}>
            {selectedactivity && !editMode && <ActivityDetails setEditModeOn={setEditModeOn} a={selectedactivity} handleCancel={handleCancel}/>}
            {!selectedactivity && <ActivityForm setEditModeOff={() => {}} mode='create'/>}
            {selectedactivity && editMode && <ActivityForm setEditModeOff={setEditModeOff} a={selectedactivity} mode='edit'/>}
        </Grid>

    </Grid>
  )
}

export default ActivityDashboard