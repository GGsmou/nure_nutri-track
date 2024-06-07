import React, { useEffect, useState } from "react";
import {
  StyleSheet,
  View,
  Text,
  Dimensions,
  ScrollView,
  TouchableOpacity,
  ActivityIndicator,
  Alert,
} from "react-native";
import { LineChart } from "react-native-chart-kit";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { router } from "expo-router";
import { useTheme } from "@react-navigation/native";
import api from "@/services/apiService";
import { WaterNote } from "@/types";
import moment from "moment";

const screenWidth = Dimensions.get("window").width;

const StatisticsScreen: React.FC = () => {
  const { colors } = useTheme();
  const [data, setData] = useState<WaterNote[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const loggedInUserId = await AsyncStorage.getItem("userId");

        const response = await api.get<WaterNote[]>("/WaterNote");
        const userEntries = response.data.filter(
          (entry) => entry.userId === loggedInUserId && entry.ml < 5000
        );
        setData(userEntries);
      } catch (error: any) {
        Alert.alert(
          "Error fetching data: ",
          JSON.stringify(error.message, null, 2)
        );
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  const sortedData = data.sort(
    (a, b) => new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime()
  );

  const currentMonth = moment().month();
  const currentMonthData = sortedData.filter(
    (entry) => moment(entry.createdAt).month() === currentMonth
  );

  const weeklyData: number[] = [];
  let weekTotal = 0;
  let currentWeek = moment().startOf("month").week();

  currentMonthData.forEach((entry) => {
    const entryDate = moment(entry.createdAt);
    const entryWeek = entryDate.week();
    while (currentWeek < entryWeek) {
      weeklyData.push(weekTotal);
      weekTotal = 0;
      currentWeek++;
    }
    weekTotal += entry.ml;
  });

  // Push remaining week total
  if (weekTotal > 0 || weeklyData.length === 0) {
    weeklyData.push(weekTotal);
  }

  const lastMonthData = {
    labels: ["Week 1", "Week 2", "Week 3", "Week 4", "Week 5"],
    datasets: [
      {
        data: weeklyData,
      },
    ],
  };

  const endDate = moment();
  const startDate = moment().subtract(6, "days");
  const lastWeekDataArray = [];
  const lastWeekDataMap: { [key: string]: number } = {};

  for (let date = startDate; date.isSameOrBefore(endDate); date.add(1, "day")) {
    lastWeekDataMap[date.format("dddd")] = 0;
  }

  sortedData.forEach((entry) => {
    const entryDate = moment(entry.createdAt);

    const day = entryDate.format("dddd");
    lastWeekDataMap[day] += entry.ml;
  });

  lastWeekDataArray.push(
    lastWeekDataMap["Monday"],
    lastWeekDataMap["Tuesday"],
    lastWeekDataMap["Wednesday"],
    lastWeekDataMap["Thursday"],
    lastWeekDataMap["Friday"],
    lastWeekDataMap["Saturday"],
    lastWeekDataMap["Sunday"]
  );

  const lastWeekData = {
    labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
    datasets: [
      {
        data: lastWeekDataArray,
      },
    ],
  };

  const monthlyData = Array(12).fill(0);
  sortedData.forEach((entry) => {
    const month = moment(entry.createdAt).month();
    monthlyData[month] += entry.ml;
  });

  const lastYearData = {
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
    datasets: [
      {
        data: monthlyData,
      },
    ],
  };

  const lastWeekTotal = sortedData
    .filter((entry) =>
      moment(entry.createdAt).isBetween(startDate, endDate, null, "[]")
    )
    .reduce((acc, entry) => acc + entry.ml, 0);

  const lastMonthTotal = sortedData
    .filter((entry) => moment(entry.createdAt).month() === currentMonth)
    .reduce((acc, entry) => acc + entry.ml, 0);

  const lastYearTotal = sortedData
    .filter((entry) => moment(entry.createdAt).year() === moment().year())
    .reduce((acc, entry) => acc + entry.ml, 0);

  const handleLogout = async () => {
    await AsyncStorage.removeItem("token");
    await AsyncStorage.removeItem("isAdmin");

    router.replace("/signin");
  };

  return (
    <ScrollView
      style={styles.container}
      contentContainerStyle={styles.contentContainerStyle}
    >
      {loading ? (
        <ActivityIndicator size="large" color={colors.text} />
      ) : (
        <>
          <Text style={[styles.title, { color: colors.text }]}>
            Water Intake
          </Text>
          <Text style={[styles.chartTitle, { color: colors.text }]}>
            Last Week
          </Text>
          <LineChart
            data={lastWeekData}
            width={screenWidth - 40}
            height={220}
            yAxisSuffix="ml"
            chartConfig={chartConfig}
            bezier
            style={styles.chart}
          />
          <Text style={[styles.chartTitle, { color: colors.text }]}>
            Last Month
          </Text>
          <LineChart
            data={lastMonthData}
            width={screenWidth - 40}
            height={220}
            yAxisSuffix="ml"
            chartConfig={chartConfig}
            bezier
            style={styles.chart}
          />
          <Text style={[styles.chartTitle, { color: colors.text }]}>
            Last Year
          </Text>
          <LineChart
            data={lastYearData}
            width={screenWidth - 40}
            height={220}
            yAxisSuffix="ml"
            chartConfig={chartConfig}
            bezier
            style={styles.chart}
          />

          <View style={styles.logoutContainer}>
            <TouchableOpacity
              style={styles.logoutButton}
              onPress={handleLogout}
            >
              <Text style={styles.logoutButtonText}>Logout</Text>
            </TouchableOpacity>
          </View>
        </>
      )}
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
  statistics: {
    marginBottom: 20,
  },
  statText: {
    fontSize: 18,
    color: "#fff",
    marginBottom: 5,
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

export default StatisticsScreen;
