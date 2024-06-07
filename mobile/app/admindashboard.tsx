import api from "@/services/apiService";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useTheme } from "@react-navigation/native";
import { router } from "expo-router";
import React, { useEffect } from "react";
import {
  StyleSheet,
  View,
  Text,
  Dimensions,
  ScrollView,
  TouchableOpacity,
} from "react-native";
import { LineChart, PieChart } from "react-native-chart-kit";

const screenWidth = Dimensions.get("window").width;

const AdminDashboard: React.FC = () => {
  const { colors } = useTheme();

  const [recipes, setRecipes] = React.useState<number>(1);
  const [exercises, setExercises] = React.useState<number>(1);

  const activeUsersDaily = [10, 10, 11, 11, 11, 11, 12];
  const activeUsersWeekly = [10, 11, 11, 12];
  const activeUsersYearly = [0, 0, 0, 0, 0, 0, 0, 1, 4, 6, 9, 12];

  const distributionData = [
    {
      name: "Exercises",
      population: exercises,
      color: "#f00",
      legendFontColor: "#7F7F7F",
      legendFontSize: 15,
    },
    {
      name: "Recipes",
      population: recipes,
      color: "#00f",
      legendFontColor: "#7F7F7F",
      legendFontSize: 15,
    },
  ];

  const handleLogout = async () => {
    await AsyncStorage.removeItem("token");
    await AsyncStorage.removeItem("isAdmin");

    router.replace("/signin");
  };

  useEffect(() => {
    api.get("/Recipes").then((response) => {
      setRecipes(response.data.length);
    });

    api.get("/Exercises").then((response) => {
      setExercises(response.data.length);
    });
  }, []);

  return (
    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.contentContainerStyle}
    >
      <Text style={[styles.title, { color: colors.text }]}>
        Service Usage Statistics
      </Text>

      <Text style={[styles.chartTitle, { color: colors.text }]}>
        Active Users - Last Week
      </Text>
      <LineChart
        data={{
          labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
          datasets: [{ data: activeUsersDaily }],
        }}
        width={screenWidth - 40}
        height={220}
        yAxisSuffix=""
        chartConfig={chartConfig}
        bezier
        style={styles.chart}
      />

      <Text style={[styles.chartTitle, { color: colors.text }]}>
        Active Users - Last Month
      </Text>
      <LineChart
        data={{
          labels: ["Week 1", "Week 2", "Week 3", "Week 4"],
          datasets: [{ data: activeUsersWeekly }],
        }}
        width={screenWidth - 40}
        height={220}
        yAxisSuffix=""
        chartConfig={chartConfig}
        bezier
        style={styles.chart}
      />

      <Text style={[styles.chartTitle, { color: colors.text }]}>
        Active Users - Last Year
      </Text>
      <LineChart
        data={{
          labels: [
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec",
          ],
          datasets: [{ data: activeUsersYearly }],
        }}
        width={screenWidth - 40}
        height={220}
        yAxisSuffix=""
        chartConfig={chartConfig}
        bezier
        style={styles.chart}
      />

      <Text style={[styles.chartTitle, { color: colors.text }]}>
        Exercises vs Recipes
      </Text>
      <PieChart
        data={distributionData}
        width={screenWidth - 40}
        height={220}
        chartConfig={chartConfig}
        accessor={"population"}
        backgroundColor={"transparent"}
        paddingLeft={"15"}
        absolute
        style={styles.chart}
      />

      <View style={styles.logoutContainer}>
        <TouchableOpacity style={styles.logoutButton} onPress={handleLogout}>
          <Text style={styles.logoutButtonText}>Logout</Text>
        </TouchableOpacity>
      </View>
    </ScrollView>
  );
};

const chartConfig = {
  backgroundColor: "#e26a00",
  backgroundGradientFrom: "#fb8c00",
  backgroundGradientTo: "#ffa726",
  decimalPlaces: 0,
  color: (opacity = 1) => `rgba(255, 255, 255, ${opacity})`,
  labelColor: (opacity = 1) => `rgba(255, 255, 255, ${opacity})`,
  style: {
    borderRadius: 16,
  },
  propsForDots: {
    r: "6",
    strokeWidth: "2",
    stroke: "#ffa726",
  },
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  contentContainerStyle: {
    flexGrow: 1,
    paddingBottom: 100,
  },
  title: {
    fontSize: 24,
    fontWeight: "bold",
    marginBottom: 20,
  },
  chartTitle: {
    fontSize: 20,
    fontWeight: "bold",
    marginBottom: 10,
    marginTop: 20,
  },
  chart: {
    marginVertical: 8,
    borderRadius: 16,
  },
  logoutContainer: {
    justifyContent: "center",
    alignItems: "center",
  },
  logoutButton: {
    backgroundColor: "#ff2c4f",
    padding: 15,
    borderRadius: 8,
    alignItems: "center",
    marginTop: 100,
    marginBottom: 50,
    width: "60%",
  },
  logoutButtonText: {
    color: "#fff",
    fontWeight: "bold",
    fontSize: 16,
  },
});

export default AdminDashboard;
